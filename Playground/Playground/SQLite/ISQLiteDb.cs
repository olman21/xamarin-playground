using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.SQLite
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
