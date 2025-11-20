using MyScheduleApp.Forms;
using MyScheduleApp.Repositories;
using System.Configuration;
using MyScheduleApp.Services;

namespace MyScheduleApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string conStr = ConfigurationManager.ConnectionStrings["ScheduleDB"].ConnectionString;
            ILoginRepository loginRepo = new SqlLoginRepository(conStr);
            ILogRepository logRepo = new SqlLogRepository(conStr);
            IScheduleRepository scheduleRepo = new SqlScheduleRepository(conStr);
            IUserRepository userRepo = new SqlUserRepository(conStr);


            ILoginService loginService = new LoginService(loginRepo);
            IScheduleService scheduleService = new ScheduleService(scheduleRepo);
            IUserService userService = new UserService(userRepo);
            ILogService logService = new LogService(logRepo);

            Application.Run(new LoginForm(loginService, logService, userService, scheduleService));
        }
    }
}