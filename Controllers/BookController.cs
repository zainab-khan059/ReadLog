using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ReadLog.Models;    // Connects to your Models folder
using ReadLog.Database;  // Connects to your Database folder

namespace ReadLog.Controllers
{
    public class BookController
    {
        // 1. Tool to GET all books from the database
        public List<Book> GetAllBooks()
        {
            List<Book> bookList = new List<Book>();
            string query = "SELECT * FROM Books"; // Make sure your database table is named Books!

            // This calls the DatabaseHelper code you pasted earlier!
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            // Turn the database rows into clean C# Book objects
            foreach (DataRow row in dt.Rows)
            {
                Book book = new Book
                {
                    BookID = Convert.ToInt32(row["Id"]),
                    Title = row["Title"].ToString(),
                    Author = row["Author"].ToString()
                };
                bookList.Add(book);
            }

            return bookList;
        }

        // 2. Tool to ADD a new book to the database
        public bool AddBook(string title, string author)
        {
            // Business Rule: Don't allow empty titles or authors
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
            {
                return false;
            }

            string query = "INSERT INTO Books (Title, Author) VALUES (@Title, @Author)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Title", title),
                new SqlParameter("@Author", author)
            };

            // This executes the insert query using your helper
            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0; // Returns true if the book was saved successfully
        }
    }
}
