using System.Diagnostics;

namespace Launcher;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

    }

    protected override void OnAppearing()
    {
        var servicesList = new List<APGService>
        {
            new APGService { serviceName = "APGFundamental", servicePath = "APG.FundamentalModulesAPIs\\APGFundamentals.sln"},
            new APGService { serviceName = "APGMembership", servicePath = "APG.MembershipModulesAPIs\\APGMembership.sln"},
            new APGService { serviceName = "APGPortalAPiGateway", servicePath = "APG.PortalAPIGateway\\APGPortalAPIGateway.sln"},
            new APGService { serviceName = "APGTransaction", servicePath = "APG.TransactionModulesAPIs\\APGTransaction.sln"},
            new APGService { serviceName = "APGExecution", servicePath = "APG.ExecutionModulesAPIs\\APGExecutions.sln"},
            new APGService { serviceName = "APGLog", servicePath = "APG.LogModulesAPIs\\APGLogs.sln"},
            new APGService { serviceName = "APGNotification", servicePath = "APG.NotificationModulesAPIs\\APGNotifications.sln"}
        };

        collectionView.ItemsSource = servicesList;
    }
    private void OnCounterClicked(object sender, EventArgs e)
    {
        var visualStodioExe = @"C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.exe";
        var apgServicesRoot = @"D:\git-repos\amwal-pay\";

        var pathList= new List<string>();
        var allCheckBoxex = collectionView.GetVisualTreeDescendants().Where(p => p.GetType() == typeof(CheckBox)).Where(p => (p as CheckBox).IsLoaded == true).ToList();
        foreach (CheckBox chbx in allCheckBoxex)
        {
            if (chbx.IsChecked )
            {
                pathList.Add(apgServicesRoot+(chbx.BindingContext as APGService).servicePath);
            }
        }
        foreach (var servicePath in pathList)
        {
            Process.Start(visualStodioExe, servicePath);
        }

    }

    void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
       
    }
}

public class APGService
{
    public string serviceName { get; set; }
    public string servicePath { get; set; }
}