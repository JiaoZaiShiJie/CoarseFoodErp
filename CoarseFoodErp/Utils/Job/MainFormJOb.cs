using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace CoarseFoodErp.Utils.Job
{
    internal class MainFormJOb : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            //全局存储数据库
            // MainForm form = (MainForm)context.Scheduler.Context.Get("MainForm");//把窗体传参进来 获得f1进行刷新

            //单个实例存储数据库
            MainForm mainForm = (MainForm)context.JobDetail.JobDataMap.Get("MainForm");
            await mainForm.RefreshDataAsync();
        }
    }
}
