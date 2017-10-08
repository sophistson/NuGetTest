Imports NLog
Imports NLog.Config
Imports NLog.Targets

Class MainWindow

Private ThisLogger As Logger 

    Protected Overrides Sub Finalize()

        If Not ThisLogger Is Nothing Then ThisLogger = Nothing

        MyBase.Finalize()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

        txtTimeStamp.Text = Now.ToLongTimeString
        ThisLogger.Debug("Time: " & txtTimeStamp.Text)

    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

        Dim MyNLogConfig As LoggingConfiguration = New LoggingConfiguration

        Dim MyTarget As FileTarget = New FileTarget With {.FileName = "${basedir}/Nlog.txt", .Layout = "${message}"}


        MyNLogConfig.AddTarget("logfile", MyTarget)
        MyNLogConfig.LoggingRules.Add(New LoggingRule("*", LogLevel.Debug, MyTarget))
        LogManager.Configuration = MyNLogConfig

        MyNLogConfig = Nothing

        ThisLogger = LogManager.GetCurrentClassLogger

    End Sub


End Class
