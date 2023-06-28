using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project_3
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public User() { }
        public User(int id,string login, string password)
        {
            this.id = id;
            this.login = login;
            this.password = password;
        }
    }
    public class Board
    {
        public int id { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public Board()
        {

        }
        public Board(int id, string name,int type)
        {
            this.id = id;
            this.name = name;
            this.type = type;
        }
    }
    public class Column
    {
        public int id { get; set; }
        public string name { get; set; }
        public int boardId { get; set; }
        public Column() { }
        public Column(int id, string name,int boardId)
        {
            this.id = id;
            this.name = name;
            this.boardId=boardId;
        }
    }
    public class MyTask
    {
        public int id { get; set; }
        public string name { get; set; }
        public string? description { get; set; }
        public int color { get; set; }
        public int columnId { get; set; }
        public MyTask() { }
        public MyTask(int id, string name, string description, int color, int columnId)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.color = color;
            this.columnId = columnId;
        }
    }
    public class BoardOwner
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int boardId {get;set;}
        public BoardOwner() { }
        public BoardOwner(int id, int userId, int boardId)
        {
            this.id = id;
            this.userId = userId;
            this.boardId = boardId;
        }
    }
    public class UserContext : DbContext
    {
        public UserContext() 
        {
            
        }
        public DbSet<User> Users { get; set; } = null!;//не должно быть равно null
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.\\Users.db");
        }
    }
    
    public class BoardContext: DbContext
    {
        public BoardContext()
        {

        }
        public DbSet<Board> Boards { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.\\Boards.db");
        }

    }
    public class ColumnContext : DbContext
    {
        public ColumnContext()
        {

        }
        public DbSet<Column> Columns { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.\\Columns.db");
        }

    }
    public class TaskContext : DbContext
    {
        public TaskContext()
        {

        }
        public DbSet<MyTask> MyTasks { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.\\Tasks.db");
        }

    }
    public class BoardOwnerContext : DbContext
    {
        public BoardOwnerContext()
        {

        }
        public DbSet<BoardOwner> BoardsOwners { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.\\BoardsOwners.db");
        }

    }

}
