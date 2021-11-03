resource "azurerm_cosmosdb_account" "properties" {
  name                = format("%s-cosmos-ukso", local.name_prefix)
  location            = azurerm_resource_group.properties.location
  resource_group_name = azurerm_resource_group.properties.name
  offer_type          = "Standard"
  kind                = "GlobalDocumentDB"

  geo_location {
    location          = azurerm_resource_group.properties.location
    failover_priority = 0
  }

  consistency_policy {
    consistency_level       = "Session"
    max_interval_in_seconds = 10
    max_staleness_prefix    = 200
  }

  tags = local.common_tags
}

resource "azurerm_cosmosdb_sql_database" "properties" {
  name                = "properties"
  resource_group_name = azurerm_cosmosdb_account.properties.resource_group_name
  account_name        = azurerm_cosmosdb_account.properties.name
  throughput          = 400
}

resource "azurerm_cosmosdb_sql_container" "properties" {
  name                  = "properties"
  resource_group_name   = azurerm_cosmosdb_account.properties.resource_group_name
  account_name          = azurerm_cosmosdb_account.properties.name
  database_name         = azurerm_cosmosdb_sql_database.properties.name
  partition_key_path    = "/id"
  partition_key_version = 1
  throughput            = 400

  indexing_policy {
    indexing_mode = "Consistent"

    included_path {
      path = "/*"
    }

    included_path {
      path = "/included/?"
    }

    excluded_path {
      path = "/excluded/?"
    }
  }
}