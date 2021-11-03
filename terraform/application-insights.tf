resource "azurerm_application_insights" "properties" {
  name                = format("%s-ai-ukso", local.name_prefix)
  location            = azurerm_resource_group.properties.location
  resource_group_name = azurerm_resource_group.properties.name
  application_type    = "web"
}
