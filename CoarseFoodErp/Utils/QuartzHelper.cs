using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz.Impl.Matchers;
using Quartz.Impl;
using Quartz;

namespace CoarseFoodErp.Utils
{
    #region Quartz帮助类

    public static class QuartzHelper
    {
        #region 字段

        /// <summary>
        /// 分组名称
        /// </summary>
        private static string GroupName;

        /// <summary>
        /// 工作作业
        /// </summary>
        private static IJobDetail Job;

        /// 身份名称 </summary>
        private static string JobKeyName;

        /// <summary>
        /// 调度器
        /// </summary>
        private static IScheduler Scheduler;

        /// <summary>
        /// 创建触发器
        /// </summary>
        private static ITrigger Trigger;

        #endregion 字段

        #region 创建调度器,并打开任务

        /// <summary>
        /// 创建调度器 并打开任务
        /// </summary>
        /// <returns></returns>
        public static async Task CreateScheduler()
        {
            var config = new System.Collections.Specialized.NameValueCollection
            {
                { "quartz.jobStore.misfireThreshold", "1" }
            };

            Scheduler = await new StdSchedulerFactory(config).GetScheduler();
            //if (x != null) //如果没有窗体,则不储存上下文数据
            //{
            //    //需要手动释放 和usingjobData一样
            //    Scheduler.Context.Put(key, x);

            //}
            await Scheduler.Start();
        }

        #endregion 创建调度器,并打开任务

        #region 创建并绑定工作

        /// <summary>
        /// 1.创建并绑定工作
        /// </summary>
        /// <typeparam name="T">实现Ijob的类</typeparam>
        /// <param name="name">身份key</param>
        /// <param name="groupName">分组名称</param>
        /// <returns></returns>
        public static void DefineJob<T>(string name, string groupName, object form = null, string key = null, Dictionary<string, object> dic = null) where T : IJob
        {
            // .UsingJobData(jobKeyName); 储存数据
            //StoreDurably  是否持久, 调用ResumeJob 重新执行
            JobKeyName = name;
            GroupName = groupName;
            Job = JobBuilder.Create<T>()
            .WithIdentity(name, groupName)//使用具有给定名称和组的 JobKey 来标识 JobDetail。
            .Build();
            //2023/6/8新添加  自动释放 存储数据
            if (form != null && key != null)
            {
                Job.JobDataMap.Put(key, form);
                if (dic != null)
                {
                    foreach (KeyValuePair<string, object> kvp in dic)
                    {
                        Job.JobDataMap.Add(kvp.Key, kvp.Value);
                    }
                }
            }
        }

        #endregion 创建并绑定工作

        #region 创建触发器

        /// <summary>
        /// 2.创建触发器
        /// </summary>
        /// <param name="triggerName">触发器名称</param>
        /// <param name="groupName">分组名称</param>
        /// <param name="cron">表达式</param>
        /// <param name="name">jobkey名称</param>
        public static void CreateTigger(string triggerName, string cron, int millSecond)
        {
            TriggerBuilder triggerBuilder = TriggerBuilder.Create().WithIdentity(triggerName, GroupName);
            if (millSecond != 0)
            {
                triggerBuilder.WithSimpleSchedule(s => s.WithInterval(TimeSpan.FromMilliseconds(10)).RepeatForever());
            }
            else
            {
                triggerBuilder.WithCronSchedule(cron);
            }

            Trigger = triggerBuilder.ForJob(JobKeyName, GroupName).Build();
        }


        #endregion 创建触发器

        #region 关闭任务

        /// <summary>
        /// 关闭任务
        /// </summary>
        public static async Task CloseScheduler()
        {
            await Scheduler.Shutdown();
        }

        #endregion 关闭任务

        #region 安排任务

        /// <summary>
        /// 安排任务
        /// </summary>
        /// <returns></returns>
        public static async Task SchedulerTask()
        {
            await Scheduler.ScheduleJob(Job, Trigger);
        }

        #endregion 安排任务

        #region 添加任务

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <typeparam name="T">集成Ijob接口</typeparam>
        /// <param name="jobkeyName">身份(唯一值)</param>
        /// <param name="groupName">分组名称</param>
        /// <param name="triggerName">"触发器名称"(唯一值)</param>
        /// <param name="cron">定时表达式</param>
        /// <param name="key">窗体名称</param>
        /// <param name="form">窗体this</param>
        public static async void AddJob<T>(string groupName, string jobkeyName, string triggerName, string cron, string key, object form, Dictionary<string, object> dic = null, int millSecond = 0) where T : IJob
        {
            DefineJob<T>(jobkeyName, groupName, form, key, dic);
            CreateTigger(triggerName, cron, millSecond);
            await Scheduler.AddJob(Job, true, true);
            await Scheduler.ScheduleJob(Trigger);
        }

        #endregion 添加任务

        #region 作业监听添加到任务调度

        /// <summary>
        /// 将作业监听其添加到任务调度中去
        /// </summary>
        /// <typeparam name="T">实现IJobListener接口</typeparam>
        public static void ListenJob<T>(string GroupName, string jobkeyName) where T : IJobListener, new()
        {
            IJobListener li = (IJobListener)Activator.CreateInstance(typeof(T), new object[] { JobKeyName });
            try
            {
                Scheduler.ListenerManager.AddJobListener(li, KeyMatcher<JobKey>.KeyEquals(new JobKey(jobkeyName, GroupName)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion 作业监听添加到任务调度

        #region 作业监听暂停

        /// <summary>
        /// 将作业监听暂停
        /// </summary>
        /// <param name="jobkeyName">监听器名称</param>
        /// <returns></returns>
        public static bool RemoveListen(string jobkeyName)
        {
            return Scheduler.ListenerManager.RemoveJobListener(jobkeyName);
        }

        #endregion 作业监听暂停

        #region 暂停分组下所有的工作任务

        /// <summary>
        /// 暂停分组下所有的工作任务
        /// </summary>
        public static async Task PauseJobs(string groupName)
        {
            await Scheduler.PauseJobs(GroupMatcher<JobKey>.GroupEquals(groupName));
        }

        #endregion 暂停分组下所有的工作任务

        #region 暂停某个分组下某个任务

        /// <summary>
        /// 暂停某个分组下某个任务
        /// </summary>
        public static async Task PauseJob(string groupName, string jobKeyName)
        {
            await Scheduler.PauseJob(new JobKey(jobKeyName, groupName));

        }

        #endregion 暂停某个分组下某个任务

        #region 恢复分组下所有的工作任务

        /// <summary>
        /// 恢复分组下所有的工作任务
        /// </summary>
        public static async Task ResumeJobs(string groupName)
        {
            await Scheduler.ResumeJobs(GroupMatcher<JobKey>.GroupEquals(groupName));

        }

        #endregion 恢复分组下所有的工作任务

        #region 恢复分组下某个任务

        /// <summary>
        /// 恢复分组下某个任务
        /// </summary>
        public static async Task ResumeJob(string groupName, string jobKeyName)
        {
            await Scheduler.ResumeJob(new JobKey(jobKeyName, groupName));
            //Scheduler.ResumeTrigger(new TriggerKey(jobKeyName, groupName));
        }

        #endregion 恢复分组下某个任务

        #region 删除分组下所有的工作任务

        /// <summary>
        /// 删除分组下所有的工作任务
        /// </summary>
        public static async Task<bool> DeleteJobs(string groupName)
        {
            var jobKeys = await Scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(groupName));
            return await Scheduler.DeleteJobs(jobKeys);
        }

        #endregion 删除分组下所有的工作任务

        #region 删除某个分组下某个任务

        /// <summary>
        /// 删除某个分组下某个任务
        /// </summary>
        public static Task<bool> DeleteJob(string groupName, string jobKeyName)
        {
            return Scheduler.DeleteJob(new JobKey(jobKeyName, groupName));
        }

        #endregion 删除某个分组下某个任务

        #region 暂停某个作业的某个触发器
        private static async Task PauseTrigger(string groupname, string triggername)
        {
            var triggerKey = new TriggerKey(triggername, groupname);
            await Scheduler.PauseTrigger(triggerKey);
        }
        #endregion

        #region 恢复某个作业的某个触发器
        public static async Task ResumeTrigger(string groupName, string triggername)
        {
            await Scheduler.ResumeTrigger(new TriggerKey(triggername, groupName));
        }
        #endregion

        #region 查看分组下所有的任务(触发器)名称

        public static Dictionary<string, object> QueryGroupName(string groupName)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            var groupMatcher = GroupMatcher<JobKey>.GroupEquals(groupName);
            var jobKeys = Scheduler.GetJobKeys(groupMatcher);
            foreach (var item in jobKeys.Result)
            {
                dic.Add(item.Name.ToString(), jobKeys.Status.ToString());
                Console.WriteLine(item.Name.ToString() + jobKeys.Status.ToString());//名称
            }
            return dic;


        }

        #endregion 查看分组下所有的任务(触发器)名称

        #region 查看分组下所有任务的触发器状态
        public async static Task<List<(string, string, string)>> QueryGroupTrigger(string groupName, string triggerName = null)
        {
            List<(string, string, string)> result = new List<(string, string, string)>();
            var groupMatcher = GroupMatcher<TriggerKey>.GroupEquals(groupName);
            var triggerKeys = await Scheduler.GetTriggerKeys(groupMatcher);
            if (triggerName != null)
            {
                var specificTriggerKey = triggerKeys.Where(t => t.Name.Equals(triggerName)).FirstOrDefault();
                if (specificTriggerKey != null)
                {
                    ITrigger detail = await Scheduler.GetTrigger(specificTriggerKey);
                    var state = await Scheduler.GetTriggerState(specificTriggerKey);
                    return new List<(string, string, string)> { (detail.JobKey.Group, detail.JobKey.Name, state.ToString()) };
                }
            }
            foreach (var triggerKey in triggerKeys)
            {
                ITrigger detail = await Scheduler.GetTrigger(triggerKey);
                var state = await Scheduler.GetTriggerState(triggerKey);
                result.Add((detail.JobKey.Group, detail.JobKey.Name, state.ToString()));
            }
            return result;
        }


        #endregion

        #region 查询指定触发器名称是否存在
        public static async Task<bool> QueryTiggerName(string groupNmae, string triggerName)
        {
            TriggerKey triggerKey = new TriggerKey(triggerName, groupNmae);
            return await Scheduler.CheckExists(triggerKey);
        }
        #endregion


    }

    #endregion 帮助类
}
