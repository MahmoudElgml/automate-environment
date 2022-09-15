using System.Diagnostics;

namespace Launcher;

public partial class MainPage : ContentPage
{
    public static string visualStodioExePath => @"C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.exe";
    public static string dockerExePath => @"C:\Program Files\Docker\Docker\Docker Desktop.exe";
    public static string vsCodeExePath => @$"C:\Users\{Environment.UserName}\AppData\Local\Programs\Microsoft VS Code\Code.exe";

    public List<APGService> visualStuioServicesList = new List<APGService>
        {
            new APGService { serviceName = "Docker", servicePath = null, exePath = dockerExePath},
            new APGService { serviceName = "APGFundamental", servicePath = "APG.FundamentalModulesAPIs\\APGFundamentals.sln",exePath=visualStodioExePath},
            new APGService { serviceName = "APGMembership", servicePath = "APG.MembershipModulesAPIs\\APGMembership.sln",exePath=visualStodioExePath},
            new APGService { serviceName = "APGPortalAPiGateway", servicePath = "APG.PortalAPIGateway\\APGPortalAPIGateway.sln", exePath = visualStodioExePath},
            new APGService { serviceName = "APGTransaction", servicePath = "APG.TransactionModulesAPIs\\APGTransaction.sln", exePath = visualStodioExePath},
            new APGService { serviceName = "APGExecution", servicePath = "APG.ExecutionModulesAPIs\\APGExecutions.sln", exePath = visualStodioExePath},
            new APGService { serviceName = "APGSmartBoxApiGateway", servicePath = "APG.SmartBoxAPIGateway\\APGSmartBoxAPIGateway.sln", exePath = visualStodioExePath},
            new APGService { serviceName = "APGNotification", servicePath = "APG.NotificationModulesAPIs\\APGNotifications.sln", exePath = visualStodioExePath},
            new APGService { serviceName = "APGLog", servicePath = "APG.LogModulesAPIs\\APGLogs.sln", exePath = visualStodioExePath},
            new APGService { serviceName = "APGPortal", servicePath = "APG.Portal", exePath = vsCodeExePath},
            new APGService { serviceName = "APGPortal.Proxy", servicePath = "APG.Portal.Proxy", exePath = vsCodeExePath},
            new APGService { serviceName = "APGeCommerceSmartBox", servicePath = "APG.eCommerceSmartBox", exePath = vsCodeExePath},
            new APGService { serviceName = "APGeCommerceSmartBox.Proxy", servicePath = "APG.eCommerceSmartBox.Proxy", exePath = vsCodeExePath}
        };

    public MainPage()
    {
        InitializeComponent();

    }

    protected override void OnAppearing()
    {

        collectionView.ItemsSource = visualStuioServicesList;
    }

    private void OnStartClicked(object sender, EventArgs e)
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

}

public class APGService
{
    public string serviceName { get; set; }
    public string servicePath { get; set; }
    public string exePath { get; set; }
}

