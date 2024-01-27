// See https://aka.ms/new-console-template for more information

using Phone_Book;

var context = new ContactContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
UserInterface.MainMenu();