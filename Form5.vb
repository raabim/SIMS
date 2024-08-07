Imports System.Data.SqlClient

Public Class Form5
    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Dim rollNoToDelete As String = TextBox1.Text

        If String.IsNullOrWhiteSpace(rollNoToDelete) Then
            MessageBox.Show("Please enter a roll number.")
            Return
        End If

        Dim con As SqlConnection = New SqlConnection("Data Source=ACER_NITRO_5;Initial Catalog=login;Integrated Security=True")
        Try
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("DELETE FROM student_detail WHERE rollno = @rollno", con)
            cmd.Parameters.AddWithValue("@rollno", rollNoToDelete)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("Record deleted successfully.")
            Else
                MessageBox.Show("No record found with the given roll number.")
            End If
            LoadData() ' Refresh data after deletion
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub LoadData()
        Dim con As SqlConnection = New SqlConnection("Data Source=ACER_NITRO_5;Initial Catalog=login;Integrated Security=True")
        Dim query As String = "SELECT [fullname], [email], [phoneno], [gender], [rollno], [course], [semester], [permanent_adr], [temporary_adr], [Father_name], [F_phoneno], [Mother_name], [M_phoneno], [Guardian_name], [G_phoneno] FROM [dbo].[student_detail]"

        Try
            con.Open()
            Dim cmd As New SqlCommand(query, con)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Me.Hide()
        Form2.Show()
    End Sub
End Class