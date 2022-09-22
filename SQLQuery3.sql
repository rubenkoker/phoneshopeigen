INSERT INTO PhonPhones(Type, username, email, opted_in) VALUES ('a','b','c',0);
/* Gets the id of the new row and inserts into the other table */
INSERT INTO user_permission (user_id, permission_id) VALUES (LAST_INSERT_ID(), 4)