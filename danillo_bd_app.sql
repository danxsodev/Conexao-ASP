create database danillo_bd_app;

use danillo_bd_app;

create table tbl_Usuario (
id_usuario int primary key auto_increment,
nm_usuario varchar(50) not null,
cargo_usuario varchar(50) not null,
dt_nasc datetime not null);

insert into tbl_Usuario
values (
	default,
	'Caramuru', 
	'Motorista', 
	'1996/01/01'
),

(
	default,
	'Lindão', 
	'Modelo', 
    '1999/02/28'
);

insert into tbl_Usuario (dt_nasc, cargo_usuario, nm_usuario)
values (
	'1999/01/10', 
	'Prof', 
	'Molina'
);

insert into tbl_Usuario (nm_usuario, cargo_usuario, dt_nasc)
values (
	'Cleber', 
	'Jogador', 
	'2010/01/01'
);

desc tbl_Usuario;

select * from tbl_Usuario;

select nm_usuario, cargo_usuario from tbl_Usuario;