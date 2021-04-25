## Schedule

#compilation instruction

before compiling
check settings in file App.config and set in connectionString your connection address to the your local server
insert your adresss with same name marker like below

First adrress "defaultConnectionString" is for create DataBase
```cs
      <add name="defaultConnectionString" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True" />
```      


The second address "salonConnectionString" is used connected with already existing base

```cs
      <add name="salonConnectionString" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Salon;Integrated Security=True" />
```



The program is being improved, therefore it is not yet fully functional

```cs
database Salon diagram
```

<a href="https://ibb.co/Nm6ZcvS"><img src="https://i.ibb.co/VQW2f1m/Bez-tytu-u.png" alt="Bez-tytu-u" border="0"></a>
