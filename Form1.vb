Imports System.Data
Imports System.Data.SqlClient

Public Class Form1
    Dim con As SqlConnection
    Dim cmd As Sqlcommand
    Dim rdr As Sqldatareader
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox2.Text = "") Then
            MsgBox("Enter the username")
            TextBox2.Focus() ' focus the username textbox'
            Exit Sub
        End If
        If (TextBox3.Text = "") Then
            MsgBox("Enter the Password")
            TextBox3.Focus() ' focus the passwrod textbox"
            Exit Sub
        End If
        Try
            con = New SqlConnection("Data Source=ACER_NITRO_5;Initial Catalog=login;Integrated Security=True")
            con.Open()
            cmd = New SqlCommand("select * from user_mgmt where username='" & TextBox2.Text & "'and password='" & TextBox3.Text & "'")
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                Form2.Show()
                Me.Hide() ' current form close"
            Else
                MsgBox("Enter Valid username and password")
                TextBox2.Text = ""
                TextBox3.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class


