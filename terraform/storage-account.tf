resource "azurerm_storage_account" "properties" {
  name                     = format("%ssaukso", local.storage_name_prefix)
  resource_group_name      = azurerm_resource_group.properties.name
  location                 = azurerm_resource_group.properties.location
  account_tier             = "Standard"
  account_replication_type = "LRS"

  tags = local.common_tags
}