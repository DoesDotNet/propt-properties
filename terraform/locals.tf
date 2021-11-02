locals {
  common_tags = {
    environment = "${var.environment}"
    project     = "${var.project}"
    system      = "${var.system}"
  }

  name_prefix         = "${var.project}-${var.system}-${var.environment}"
  storage_name_prefix = "${var.project}${substr(var.system,0,5)}${var.environment}"

  locations = {
    "UK South" = "ukso"
    "UKSouth"  = "ukso"
    "uksouth"  = "ukso"
  }
}