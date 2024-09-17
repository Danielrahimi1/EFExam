using EFExam.IO;
using EFExam.IO.Menus;
using EFExam.Persistence;

var consoleUi = new ConsoleUi();
var dbContext = new ApplicationDbContext();

var mainMenu = new MainMenu(dbContext, consoleUi);
// mainMenu.Show();