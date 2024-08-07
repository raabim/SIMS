Imports System.Data.SqlClient

Public Class Form4
    Dim con As New SqlConnection("Data Source=ACER_NITRO_5;Initial Catalog=login;Integrated Security=True")
    Dim cmd As SqlCommand
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub
    Private Sub LoadData()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT * FROM student_detail" ' 

            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)

            da.Fill(dt)
            DataGridView1.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("An error occurred while fetching data: " & ex.Message)
        Finally

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs)

    End Sub
End Class

