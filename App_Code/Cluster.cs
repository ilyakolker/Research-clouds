﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cluster
/// </summary>
public class Cluster
{
    //Utility:
    DBServices db;

    //Fields:
    int id;
    string name;
    List<Keyword> keywords;
    List<User> users;


    //Properties:
    public int Id { get { return id; } }
    public string Name { get { return name; } }
  
    public List<User> Users {
        get
        {
                return users;
        }
    }
    public List<Keyword> Keywords {
        get
        {
            if (keywords==null)
            {
                keywords = db.GetClusterKeywords(id);
            }
            return keywords;
        }
    }


    //Constructors:
    public Cluster()
    {
        db = new DBServices();
    }

    public Cluster(int id, string name) 
    {
        db = new DBServices();
        this.id = id;
        this.name = name;      
    }

    //Methods:
    public List<Cluster> GetAllClusters()
    {
        return db.GetAllClusters();
    }

    public Cluster GetClusterById(int _id)
    {
        return db.GetClusterById(_id);
    }
   

    public override string ToString()
    {
        string info = "ID: " + id + "<br>";
        info += "Name: " + name + "<br>";

        return base.ToString();
    }
    
}