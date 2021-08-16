db.createCollection("Users", {
    validator: {
        $jsonSchema: {
            bsonType: "object",
            title: "User Info",
            properties: {
                user_fullname: {
                    bsonType: "string"
                },
                user_type: {
                    bsonType: "int"
                },
                user_type_name: {
                    bsonType: "string"
                },
                user_role: {
                    bsonType: "int"
                },
                user_role_name: {
                    bsonType: "string"
                },
                license_type: {
                    bsonType: "int"
                },
                license_type_name: {
                    bsonType: "string"
                },
                status: {
                    bsonType: "int"
                },
                status_name: {
                    bsonType: "string"
                },
                created_date_in_long: {
                    bsonType: "long"
                },
                created_date_string: {
                    bsonType: "string"
                },
                modified_date_in_long: {
                    bsonType: "long"
                },
                modified_date_string: {
                    bsonType: "string"
                }
            }
        }
    }
});