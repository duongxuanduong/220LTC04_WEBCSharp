
create table tbl_admin(
	admin_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	username VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL,
	user_status int NOT NULL,
)

insert into tbl_admin(username,password)
values('duongls2ls','e10adc3949ba59abbe56e057f20f883e')


create table tbl_brand(
	brand_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	brand_name NVARCHAR(255) not null,
	brand_des NVARCHAR(255) not null,
	brand_status int not null,
)

create table tbl_category(
	category_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	category_name NVARCHAR(255) not null,
	category_des NVARCHAR (255) NOT NULL,
	category_status int not null
)


create table tbl_product(
	product_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	category_id INT FOREIGN KEY (category_id) REFERENCES tbl_category (category_id),
	brand_id INT FOREIGN KEY (brand_id) REFERENCES tbl_brand (brand_id),
	product_name Nvarchar(255) not null,
	product_des Nvarchar(255) not null,
	product_price decimal(10,2) not null,
	product_image Nvarchar(255),
	product_status int not null,
	product_quantity int not null,
)

create table tbl_customer(
	customer_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	customer_name Nvarchar(255) not null,
	customer_email Nvarchar(255) not null,
	customer_password varchar(50) not null,
	customer_phone varchar(255),
	customer_status int NOT NULL,
)
create table tbl_order(
	order_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	customer_id INT FOREIGN KEY (customer_id) REFERENCES tbl_customer (customer_id),
	order_total decimal(10,2) not null ,
	order_status int not null,
	order_address nvarchar(255) not null,
	order_time varchar(50)
)

create table tbl_order_detail(
order_detail_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
order_id INT FOREIGN KEY (order_id) REFERENCES tbl_order (order_id),
product_id int not null,
product_name Nvarchar(255) not null,
product_image Nvarchar(255) not null,
product_price decimal(10,2) not null,
product_quantity int not null
)
