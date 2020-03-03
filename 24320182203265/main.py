import serial #导入模块
try:
  #端口，GNU / Linux上的/ dev / ttyUSB0 等 或 Windows上的 COM3 等
  portx="COM1"
  #波特率
  bps=115200
  #超时设置,None：永远等待操作，0为立即返回请求结果，其他值为等待超时时间(单位为秒）
  timex=5
  # 打开串口，并得到串口对象
  ser=serial.Serial(portx,bps,timeout=timex)

  # 写数据
  result=ser.write("我是韬哥".encode("gbk"))
  print("写总字节数:",result)

  ser.close()#关闭串口

except Exception as e:
    print("---异常---：",e)