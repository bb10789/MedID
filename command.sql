CREATE TABLE ID (
  id INT PRIMARY KEY NOT NULL UNIQUE,
  fname VARCHAR(20),
  lname VARCHAR(20),
  phone VARCHAR(13),
  location VARCHAR(150)
);


CREATE TABLE Month (
  mid int PRIMARY KEY,
  month VARCHAR(10)
);

CREATE TABLE Interaction (
  Interaction_id INT PRIMARY KEY,
  month_id INT REFERENCES Month(mid),
  day_of_month INT,
  id1 INT,
  id2 INT,
  FOREIGN KEY (id1) REFERENCES ID(id),
  FOREIGN KEY (id2) REFERENCES ID(id)
);




SELECT i.id2 AS otherID, COUNT(*) over() AS cnt
FROM Interaction as i
WHERE i.id1 == ?

INSERT INTO ID VALUES (?, ?, ?, ?, ?)
INSERT INTO ID VALUES (0, "Kelvin", "Kam", 206973, "Seattle WA")
INSERT INTO ID VALUES (1, "Chris", "Yee", 123456, "BOSTON WA")
INSERT INTO INTERACTION VALUES (0, 1, 30, 0, 1)
INSERT INTO INTERACTION VALUES (?, ?, ?, ?, ?)
DELETE FROM INTERACTION; DELE FROM ID;
