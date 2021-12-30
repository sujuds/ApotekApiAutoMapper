/*
 Navicat Premium Data Transfer

 Source Server         : LocalMySqlConn
 Source Server Type    : MySQL
 Source Server Version : 80027
 Source Host           : localhost:3306
 Source Schema         : db_apotek

 Target Server Type    : MySQL
 Target Server Version : 80027
 File Encoding         : 65001

 Date: 30/12/2021 13:27:54
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for obats
-- ----------------------------
DROP TABLE IF EXISTS `obats`;
CREATE TABLE `obats`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `Kode` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
  `Nama` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
  `Stok` int(0) NOT NULL,
  `Harga` int(0) NOT NULL,
  `Foto` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of obats
-- ----------------------------
INSERT INTO `obats` VALUES (1, '111', 'Paracetamol', 3, 500, NULL);
INSERT INTO `obats` VALUES (2, '222', 'Amoxicillin', 6, 300, NULL);
INSERT INTO `obats` VALUES (3, 'tes1', 'add', 2, 100, NULL);
INSERT INTO `obats` VALUES (6, '777', 'VitB', 8, 200, NULL);

-- ----------------------------
-- Table structure for transaksidetails
-- ----------------------------
DROP TABLE IF EXISTS `transaksidetails`;
CREATE TABLE `transaksidetails`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `TransaksiId` int(0) NULL DEFAULT NULL,
  `ObatId` int(0) NULL DEFAULT NULL,
  `Jumlah` int(0) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `FK_TransaksiDetails_Obats_ObatsiId_idx`(`ObatId`) USING BTREE,
  INDEX `FK_TransaksiDetails_Transaksis_TransaksiId_idx`(`TransaksiId`) USING BTREE,
  CONSTRAINT `FK_TransaksiDetails_Obats_ObatsiId` FOREIGN KEY (`ObatId`) REFERENCES `obats` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_TransaksiDetails_Transaksis_TransaksiId` FOREIGN KEY (`TransaksiId`) REFERENCES `transaksis` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 12 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of transaksidetails
-- ----------------------------
INSERT INTO `transaksidetails` VALUES (1, 1, 1, 2);
INSERT INTO `transaksidetails` VALUES (2, 1, 2, 1);
INSERT INTO `transaksidetails` VALUES (3, 2, 2, 2);
INSERT INTO `transaksidetails` VALUES (4, 3, 1, 2);
INSERT INTO `transaksidetails` VALUES (5, 3, 2, 2);
INSERT INTO `transaksidetails` VALUES (10, 7, 1, 2);
INSERT INTO `transaksidetails` VALUES (11, 7, 2, 1);

-- ----------------------------
-- Table structure for transaksis
-- ----------------------------
DROP TABLE IF EXISTS `transaksis`;
CREATE TABLE `transaksis`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `Kode` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
  `Total` int(0) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 8 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of transaksis
-- ----------------------------
INSERT INTO `transaksis` VALUES (1, 'T271220215', 1300);
INSERT INTO `transaksis` VALUES (2, 'T271220217', 600);
INSERT INTO `transaksis` VALUES (3, 'T271220213', 1600);
INSERT INTO `transaksis` VALUES (7, 'Ttes', 1300);

SET FOREIGN_KEY_CHECKS = 1;
