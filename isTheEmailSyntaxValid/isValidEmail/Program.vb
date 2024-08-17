Imports System.IO
Imports System.Text.RegularExpressions

Module Module1
    Sub Main(args As String())
        If args.Length <> 2 Then
            Console.WriteLine("Usage: EmailValidator <email> <outputFilePath>")
            Return
        End If

        Dim email As String = args(0)
        Dim outputFilePath As String = args(1)

        ' E-posta formatýný doðrulamak için düzenli ifade
        Dim emailRegex As New Regex("^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}$")
        Dim isValid As Boolean = emailRegex.IsMatch(email)

        ' Sonucu dosyaya yazma
        Dim result As String = If(isValid, "Valid email address", "Invalid email address")
        Try
            File.WriteAllText(outputFilePath, result)
            Console.WriteLine($"Result written to {outputFilePath}")
        Catch ex As Exception
            Console.WriteLine($"Error writing to file: {ex.Message}")
        End Try
    End Sub
End Module

