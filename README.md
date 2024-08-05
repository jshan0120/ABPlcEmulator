# ABPlcEmulator provides server using libplctag Library.
This program automatically open server with tags so that the user can simulate plc and test custom programs.


## Using Docker Image
  **jshan0120/ab_server:4.0**
  The image was build from: https://github.com/jshan0120/libplctag (Dockerfile not included here)


## Create Tag file
**Tag Format**

  TAG_NAME:TAG_TYPE[ELEM_SIZE]  
  
**Element Size**

  Can create maximum 3 dimentions using ,(comma)  
  
**Tag Type**

- SINT : 1-byte signed integer
- INT : 2-byte signed integer
- DINT : 4-byte signed integer
- LINT : 8-byte signed integer
- REAL : 4-byte floating point number
- LREAL : 8-byte floating point number
- STRING : 82-byte string
- BOOL : 1-byte boolean value  


## Maunual
- Set Tag FilePath to use
- Add New Tags
- Confirm Tag before open server when the settings of tags modified
- Open server with docker
- When server opened, user can set the value of each tag or read the values of all tags
- Close server
- Modify the settings of tags after closing server
