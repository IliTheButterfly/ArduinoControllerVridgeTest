#pragma once

#ifndef _ERRORCODES_h
#define _ERRORCODES_h

#define ERR_NONE					0b00000000
#define ERR_LEFT					0b10000000
#define ERR_RIGHT					0b01000000
#define ERR_MPU						0b00100000
#define ERR_ARDUINO					0b00010000
#define ERR_TRANSMIT_FAILED			0b00001000
#define ERR_MPU_INIT_MEM_LOAD_FAIL	0b00000000 | ERR_MPU
#define ERR_MPU_DMP_CONFIG			0b00000001 | ERR_MPU
#define ERR_ADDRESS_NACK			0b00000000 | ERR_TRANSMIT_FAILED
#define ERR_REG_NACK				0b00000001 | ERR_TRANSMIT_FAILED
#define ERR_STREAM_ENDED			0b00000010 | ERR_TRANSMIT_FAILED
#define ERR_MASTER_MEM_FAIL			0b00000001

#endif