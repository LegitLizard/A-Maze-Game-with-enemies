Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            Form2.CreateWinForm()
            Form2.Visible = False
            Form4.CreateLoseForm()
            Form1.StartPosition = 1
            Form2.StartPosition = 1
            Form3.StartPosition = 1
            Form4.StartPosition = 1
            Form4.Visible = False
            Form1.Width = 1200
            Form1.Height = 1039
            Form2.Width = 500
            Form2.Height = 500
            Form3.Width = 500
            Form3.Height = 500
            Form3.BackColor = Color.Orange
            Form4.Width = 500
            Form4.Height = 500
        End Sub
    End Class
End Namespace
