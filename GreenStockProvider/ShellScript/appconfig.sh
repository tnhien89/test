db.createCollection("AppConfig", {
    validator: {
        $jsonSchema: {
            bsonType: "object",
            title: "AppConfig",
            properties: {
                app_version: {
                    bsonType: 'string'
                },
                last_login_date_in_long: {
                    bsonType: 'long'
                },
                last_login_date_string: {
                    bsonType: 'string'
                },
                tdameritrade_cache: {
                    bsonType: "object"
                },
                order_listing: {
                    bsonType: "array"
                },
                strategy_listing: {
                    bsonType: "array"
                }
            }
        }
    }
});