use Librox
CREATE TABLE Usuarios(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Nombre VARCHAR(50),
Usuario NVARCHAR(20),
Correo NVARCHAR(50),
Contraseña NVARCHAR(50),
Cumpleaños NVARCHAR(10),
TipoUsuario INT DEFAULT 0
)
SELECT * FROM Usuarios
truncate table Usuarios
EXEC [SPVerifyUser] 'Dani Vazquez','auditore_123456789huesos@hotmail.com'

EXEC [SPVerifyUser] 'David May','DavidMAY_CEN@hotmail.com'

EXEC [SPVerifyUser] 'Dani Vazquez','auditore_123456789huesos@hotmail.com','12/17/1996'

CREATE TABLE Libros(
IDLibro INT PRIMARY KEY NOT NULL IDENTITY(1,1),
NombreLibro VARCHAR(50),
GeneroLibro NVARCHAR(50),
ReseñaLibro NVARCHAR(50),
PrecioLibro Numeric(14,6)
)
Drop Table lIBROS
dROP TABLE UsuarioLibro
Drop Table Usuarios

CREATE TABLE UsuarioLibro(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
IDUsuario INT,
FOREIGN KEY (IDUsuario) REFERENCES Usuarios(ID),
IDLibro INT,
FOREIGN KEY (IDLibro) REFERENCES lIBROS(IDLibro)
)


Select Contraseña,Tipousuario from Usuarios where Usuario = 'Evazquez'