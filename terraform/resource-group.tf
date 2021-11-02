resource "azurerm_resource_group" "properties" {
  name     = format("%s-rg-ukso", local.name_prefix)
  location = "UK South"

  tags = local.common_tags
}