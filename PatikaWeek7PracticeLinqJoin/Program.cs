using PatikaWeek7PracticeLinqJoin;

List<Book> books = new List<Book>(); // Kitap Listesi

books.Add(new Book { BookId = 1, Title = "Kar", AuthorId = 1});
books.Add(new Book { BookId = 2, Title = "İstanbul", AuthorId = 1});
books.Add(new Book { BookId = 3, Title = "10 Minutes 38 Seconds in This Strange World", AuthorId = 2});
books.Add(new Book { BookId = 4, Title = "Beyoğlu Rapsodisi", AuthorId = 3});

List<Author> authorList = new List<Author>(); // Yazar Listesi

authorList.Add(new Author { AuthorId = 1, Name = "Orhan Pamuk" });
authorList.Add(new Author { AuthorId = 2, Name = "Elif Şafak" });
authorList.Add(new Author { AuthorId = 3, Name = "Ahmet Ümit" });


// Join işlemi ile her iki liste birleştirildi

var booksWithAuthors = books.Join(authorList, 
                                  book => book.AuthorId,
                                  author => author.AuthorId,
                                  (book, author) => new
                                  {
                                      Title = book.Title, // Kitap adı ve Yazar adı seçildi
                                      AuthorName = author.Name
                                  });


// Aynı işlem

//var booksWithAuthors = from book in books
//                       join author in authorList on book.AuthorId equals author.AuthorId
//                       select new
//                       {
//                           Title = book.Title,
//                           AuthorName = author.Name
//                       };

foreach (var item in booksWithAuthors) // Oluşturduğumuz koleksiyonu çalıtırdık 
{
    Console.WriteLine($"Kitap Adı: {item.Title}, Yazar: {item.AuthorName}");
}
