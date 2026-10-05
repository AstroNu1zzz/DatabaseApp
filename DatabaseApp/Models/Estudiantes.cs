using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseApp.Models;

public class Estudiante
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Grupo { get; set; }
    public string RFC { get; set; }
    public int Numero { get; set; }
}