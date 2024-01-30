# WindowsDefenderHelper

C# class that can add/remove/read exclusions on Windows Defender. This requires Administrator Privilege.

## How to use

`WindowsDefenderHelper` class provides all features to add/remove/read exclusions on Windows Defender. It calls PowerShell internally.

Functions:
- IsUserAdministrator()
- GetExclusionPath()
- GetExclusionProcess()
- GetExclusionExtension()
- AddExclusionPath(string value)
- AddExclusionProcess(string value)
- AddExclusionExtension(string value)
- RemoveExclusionPath(string value)
- RemoveExclusionProcess(string value)
- RemoveExclusionExtension(string value)
