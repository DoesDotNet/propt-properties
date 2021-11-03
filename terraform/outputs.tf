output "instrumentation_key" {
  value = azurerm_application_insights.properties.instrumentation_key
  sensitive = true
}

output "app_id" {
  value = azurerm_application_insights.properties.app_id
}