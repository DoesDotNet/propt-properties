resource "azurerm_servicebus_topic" "properties-created" {
  name                = "propt.properties.propterycreated.v1"
  resource_group_name = var.servicebus_name
  namespace_name      = var.servicebus_rg

  enable_partitioning = true
}

resource "azurerm_servicebus_namespace_authorization_rule" "properties" {
  name                = "property-auth-rule"
  namespace_name      = var.servicebus_name
  resource_group_name = var.servicebus_rg

  listen = true
  send   = true
  manage = false
}

data "azurerm_servicebus_namespace_authorization_rule" "properties" {
  name                = "property-auth-rule"
  namespace_name      = var.servicebus_name
  resource_group_name = var.servicebus_rg
}