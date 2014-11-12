-- BattleNetShop.Data.MySql.Salereport
CREATE TABLE `salereports` (
    `vendorName` nvarchar(500) NOT NULL,    -- _vendorName
    `totalQuantitySold` integer NOT NULL,   -- _totalQuantitySold
    `totalIncomes` integer NOT NULL,        -- _totalIncomes
    `report_id` integer AUTO_INCREMENT NOT NULL, -- _report_id
    `product_id` integer NOT NULL,          -- _product_id
    `productName` nvarchar(500) NOT NULL,   -- _productName
    CONSTRAINT `pk_salereports` PRIMARY KEY (`report_id`)
) ENGINE = InnoDB;

ALTER TABLE `salereports` ADD INDEX `product_id`(`product_id`);

