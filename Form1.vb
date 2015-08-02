
Imports MySql.Data.MySqlClient

Public Class Form1
    'Declare connection client
    Dim MysqlConn As MySqlConnection
    'ability to query the database
    Dim COMMAND As MySqlCommand

    'connection function
    Sub Connection()

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password=root;"

        Try
            MysqlConn.Open()
        Catch ex As Exception
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "Connection Errors Try again"
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCheckConnection.Click

        'call the connection method
        Connection()
    End Sub


    Private Sub btnSignin_Click(sender As Object, e As EventArgs) Handles btnSignin.Click
        Connection()

        'reader to the database
        Dim READER As MySqlDataReader
        Dim count As Integer = 0
        Try
            MysqlConn.Open()
            Dim Query As String = "SELECT * FROM database.person where username='" & txtUsername.Text & "' AND password = '" & txtPassword.Text & "'"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader

            While READER.Read
                count += 1
            End While

            'validate the inputs
            If count = 1 Then
                Invoicer.Show()
                Me.Hide()

            Else
                lblMessage.ForeColor = Color.DarkRed
                lblMessage.Text = "User not registered"
            End If

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try
    End Sub
End Class
