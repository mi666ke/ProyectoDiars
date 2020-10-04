
create table Cliente(

    idCliente INT IDENTITY PRIMARY KEY,
    codigo VARCHAR(50),
    nombres VARCHAR(50),
    apellidos VARCHAR(50),
    dni NVARCHAR(8),
    fechaNac DATE,
    correo VARCHAR(100),
    telefono VARCHAR(20),
    usuario VARCHAR(50),
    passwd VARCHAR(200)

)

INSERT into Cliente values('123','Miguel','Aliaga','75489656','10/11/1998','asd@gmail.com','123456789','1234','qwerty')

SELECT * FROM Cliente


create table Doctor(
    idDoctor int IDENTITY PRIMARY KEY,
    nombres varchar(50),
    apellidos varchar(50),
    codigoCol varchar(50),
    casaEstudio varchar(100),
    titulo varchar(100),
    dni nchar(8),
    correo varchar(100),
    telefono varchar(20),
    usuario VARCHAR(50),
    passwd  VARCHAR(50)
)


insert into Doctor values(
    'Pedro','Navaja','0123456',
    'Universidad Privada del Norte',
    'Rehabilitacion oral',
    '12345678','navaja@mail.com',
    '987456123','navaja','navaja'
)

insert into Doctor values(
    'Karl','Xd','065498',
    'Universidad Privada del Norte',
    'Cirujano dentista',
    '12387456','karl@mail.com',
    '123456788','karl','karl'
)

insert into Doctor values(
    'Jaime','Abc','012322',
    'Universidad Nacional de Cajamarca',
    'Estética dental',
    '22222222','jaime@mail.com',
    '982231223','jaime','jaime'
)

select * from Doctor


create table Cita(
    idCita int IDENTITY PRIMARY KEY,
    fecha DATE,
    horaInicio VARCHAR(10),
    horaFin VARCHAR(10),
    estado VARCHAR(10),
    idCliente int,
    idDoctor int,
    monto DECIMAL(8,4)
)

select * from Cita