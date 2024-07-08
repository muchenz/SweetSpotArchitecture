
CREATE TABLE
	IF NOT EXISTS products(
	id UUID PRIMARY KEY,
	name TEXT NOT NULL,
	category TEXT NOT NULL, 
	sub_category TEXT NOT NULL
	);


CREATE TABLE
	IF NOT EXISTS reviews(
	id UUID PRIMARY KEY,
	product_id UUID NOT NULL,
	rating INT NOT NULL,
	text TEXT NOT NULL, 
	CONSTRAINT fk_product FOREIGN KEY (product_id) REFERENCES products(id)
	);

 --jeszcze index chyba dla klucza obcego