using Microsoft.Win32;
using System.Diagnostics;

namespace Launcher;

public partial class MainPage : ContentPage
{
    public static string visualStodioExe => @"C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.exe";
    public static string dockerExe => @"C:\Program Files\Docker\Docker\Docker Desktop.exe";
    public static string vsCodeExe => LocateExe("code");

    public List<APGService> visualStuioServicesList = new List<APGService>
        {
            new APGService { serviceName = "APGFundamental", servicePath = "APG.FundamentalModulesAPIs\\APGFundamentals.sln",exePath=visualStodioExe},
            new APGService { serviceName = "APGMembership", servicePath = "APG.MembershipModulesAPIs\\APGMembership.sln",exePath=visualStodioExe},
            new APGService { serviceName = "APGPortalAPiGateway", servicePath = "APG.PortalAPIGateway\\APGPortalAPIGateway.sln", exePath = visualStodioExe},
            new APGService { serviceName = "APGTransaction", servicePath = "APG.TransactionModulesAPIs\\APGTransaction.sln", exePath = visualStodioExe},
            new APGService { serviceName = "APGExecution", servicePath = "APG.ExecutionModulesAPIs\\APGExecutions.sln", exePath = visualStodioExe},
            new APGService { serviceName = "APGLog", servicePath = "APG.LogModulesAPIs\\APGLogs.sln", exePath = visualStodioExe},
            new APGService { serviceName = "APGNotification", servicePath = "APG.NotificationModulesAPIs\\APGNotifications.sln", exePath = visualStodioExe}
        };
    public MainPage()
    {
        InitializeComponent();

    }

    protected override void OnAppearing()
    {
        collectionView.ItemsSource = visualStuioServicesList;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        var apgServicesRoot = @"D:\git-repos\amwal-pay\";
        var allCheckBoxex = collectionView.GetVisualTreeDescendants().OfType<CheckBox>().Where(p => p.IsLoaded && p.IsChecked).ToList();
        foreach (CheckBox chbx in allCheckBoxex)
        {
            var service = chbx.BindingContext as APGService;
            if (!string.IsNullOrWhiteSpace(service.exePath))
            {
                Process.Start(service.exePath, apgServicesRoot + service.servicePath);
            }
        }

    }

    private static string LocateExe(String filename)
    {
        String path = Environment.GetEnvironmentVariable("path");
        String[] folders = path.Split(';');
        foreach (String folder in folders)
        {
            if (File.Exists(folder + filename))
            {
                return folder + filename;
            }
            else if (File.Exists(folder + "\\" + filename))
            {
                return folder + "\\" + filename;
            }
        }
        return String.Empty;
    }

}

public class APGService
{
    public string serviceName { get; set; }
    public string servicePath { get; set; }
    public string exePath { get; set; }
}

