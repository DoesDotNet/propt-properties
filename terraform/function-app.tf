resource "azurerm_app_service_plan" "properties" {
  name                = format("%s-plan-ukso", local.name_prefix)
  location            = azurerm_resource_group.properties.location
  resource_group_name = azurerm_resource_group.properties.name
  kind                = "FunctionApp"

  sku {
    tier = "Dynamic"
    size = "Y1"
  }
}

resource "azurerm_function_app" "properties" {
  name                       = format("%s-func-ukso", local.name_prefix)
  location                   = azurerm_resource_group.properties.location
  resource_group_name        = azurerm_resource_group.properties.name
  app_service_plan_id        = azurerm_app_service_plan.properties.id
  storage_account_name       = azurerm_storage_account.properties.name
  storage_account_access_key = azurerm_storage_account.properties.primary_access_key
  version                    = "~4"

  app_settings = {
    "FUNCTIONS_WORKER_RUNTIME"        = "dotnet-isolated"
    "CosmosSettings:ConnectionString" = "${azurerm_cosmosdb_account.properties.endpoint};AccountKey=${azurerm_cosmosdb_account.properties.primary_master_key};"
    "CosmosSettings:DatabaseName"     = azurerm_cosmosdb_sql_database.properties.name
    "CosmosSettings:ContainerName"    = azurerm_cosmosdb_sql_container.properties.name
  }

  site_config {
    use_32_bit_worker_process = false
  }
}