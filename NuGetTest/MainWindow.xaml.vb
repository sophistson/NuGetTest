Imports NLog


Class MainWindow

Private ThisLogger As Logger = LogManager.GetCurrentClassLogger



    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        txtTimeStamp.Text = Now.ToLongTimeString

        ThisLogger.Info("Time: " & txtTimeStamp.Text)

    End Sub
End Class
