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
        // Get the number of books based on their status (Read vs. Currently Reading)
        public int GetBookCountByStatus(string status)
        {
            string query = "SELECT COUNT(*) FROM Books WHERE ReadingStatus = @Status";
            SqlParameter[] parameters = { new SqlParameter("@Status", status) };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            return 0;
        }

        // Get the titles of the 5 most recently added books
        public List<string> GetRecentBookTitles()
        {
            List<string> titles = new List<string>();
            string query = "SELECT TOP 5 Title FROM Books ORDER BY BookID DESC"; // Using BookID based on your model update!

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                titles.Add(row["Title"].ToString());
            }
            return titles;
        }
        // 1. Fetch all books from the database as a DataTable
        public DataTable GetLibraryBooks()
        {
            string query = "SELECT Id, Title, Author, Genre, ReadingStatus, Rating FROM Books";
            return DatabaseHelper.ExecuteQuery(query);
        }

        // 2. Delete a book by its primary ID key
        public bool DeleteBook(int bookId)
        {
            string query = "DELETE FROM Books WHERE Id = @Id";
            SqlParameter[] parameters = {
        new SqlParameter("@Id", bookId)
    };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
    }
}
