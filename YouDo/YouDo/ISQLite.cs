using System;
using SQLite.Net;

namespace YouDo
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

