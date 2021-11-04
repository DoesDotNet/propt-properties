variable "environment" {
  type = string
}

variable "project" {
  type    = string
  default = "propt"
}

variable "system" {
  type    = string
  default = "properties"
}

variable "servicebus_name" {
  type = string
}

variable "servicebus_rg" {
  type = string
}