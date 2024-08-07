Imports System.Data.SqlClient

Public Class Form3
    Private con As New SqlConnection("Data Source=ACER_NITRO_5;Initial Catalog=login;Integrated Security=True")
    Private rollNo As String

    Public Sub New(rollNo As String)
        Me.rollNo = rollNo
        InitializeComponent()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FilterData(rollNo)
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        FilterData(TextBox1.Text)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        FilterData("")
    End Sub

    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "SELECT fullname,email,phoneno,gender,rollno,course
      ,semester ,permanent_adr ,temporary_adr ,father_name,f_phoneno,mother_name
      ,m_phoneno ,Guardian_name,G_phoneno FROM dbo.student_detail
        WHERE rollno LIKE @rollno"

        Try
            con.Open()
            Dim command As New SqlCommand(searchQuery, con)
            command.Parameters.AddWithValue("@rollno", "%" & valueToSearch & "%")
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Guna2HtmlLabel2_Click(sender As Object, e As EventArgs)

    End Sub
End Class



