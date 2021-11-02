resource "azurerm_search_service" "properties" {
  name                = format("%s-search-ukso", local.name_prefix)
  resource_group_name = azurerm_resource_group.properties.name
  location            = azurerm_resource_group.properties.location
  sku                 = "basic"
}