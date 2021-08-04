
## Change dll path to the dll built from the sample project: "TaskHangTest".

Add-Type -Path ".\TaskHangTest\bin\Debug\netstandard2.0\TaskHangTest.dll"


##To repro the issue, load the "System.Windows.Forms" dll

[void][System.Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms")

$UserAdminForm = New-Object System.Windows.Forms.Form


## Following commands will hang if "System.Windows.Forms" is loaded in, but it works well if "System.Windows.Forms" dll is not loaded.

$t = [TaskHangTest.TaskTest]::RunTask();
$t.Wait();

