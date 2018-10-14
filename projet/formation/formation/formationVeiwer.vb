Public Class formationVeiwer

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As Windows.Forms.DateRangeEventArgs) Handles cmdagenda.DateChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        MsgBox(CStr(Me.cmdagenda.SelectionRange.Start))
        'Me.Label1.Text = CStr(Me.MonthCalendar1.SelectionRange.Start)





    End Sub
End Class