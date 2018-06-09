
## 各终端对消息类型的解读

<table class="tg">
  <tr>
    <th class="tg-c3ow">消息里类型\终端</th>
    <th class="tg-c3ow">客户端(房主)</th>
    <th class="tg-c3ow">客户端(房客)</th>
    <th class="tg-c3ow">大厅服务器</th>
    <th class="tg-c3ow">决斗服务器</th>
    <th class="tg-c3ow">版本服务器</th>
  </tr>
  <tr  align="center">
    <td class="tg-abip">CREATE</td>
    <td class="tg-abip">创建房间成功<br>收到房间ID</td>
    <td class="tg-abip"></td>
    <td class="tg-abip">玩家创建一个新房间</td>
    <td class="tg-abip"></td>
  </tr>
  <tr  align="center">
    <td class="tg-c3ow">JOIN<br>(大厅服务器)</td>
    <td class="tg-c3ow">加入房间成功<br>收到玩家信息</td>
        <td class="tg-c3ow">加入房间成功<br>收到房间信息</td>
    <td class="tg-c3ow">玩家加入一个房间</td>
    <td class="tg-c3ow"></td>
    <td class="tg-c3ow"></td>
  </tr>
  <tr  align="center">
    <td class="tg-c3ow">JOIN<br>(决斗服务器)</td>
    <td class="tg-c3ow" colspan = "2">成功连接决斗服务器</td>
    <td class="tg-c3ow"></td>
    <td class="tg-c3ow">玩家连接</td>
    <td class="tg-c3ow"></td>
  </tr>
  <tr  align="center">
    <td class="tg-abip">LEAVE</td>
    <td class="tg-abip" colspan="2">对方离开房间</td>
    <td class="tg-abip">玩家离开一个房间</td>
    <td class="tg-abip"></td>
    <td class="tg-abip"></td>
  </tr>
  <tr  align="center">
    <td class="tg-c3ow">KICK_OUT</td>
    <td class="tg-c3ow">对方已被踢出房间</td>
    <td class="tg-c3ow">被踢出房间</td>
    <td class="tg-c3ow">玩家(房主)将玩家(房客)踢出房间</td>
    <td class="tg-c3ow"></td>
    <td class="tg-c3ow"></td>
  </tr>
  <tr  align="center">
    <td class="tg-abip">PREPARED</td>
    <td class="tg-abip">对方进入/取消准备状态</td>
    <td class="tg-abip">成功进入/取消准备状态</td>
    <td class="tg-abip">玩家(房客)进入/取消准备状态</td>
    <td class="tg-abip"></td>
    <td class="tg-abip"></td>
  </tr>
  <tr  align="center">
    <td class="tg-c3ow">STARTED</td>
    <td class="tg-c3ow">成功进入/取消开始状态</td>
    <td class="tg-c3ow">对方进入/取消开始状态</td>
    <td class="tg-c3ow">玩家(房主)进入/准备状态</td>
    <td class="tg-c3ow"></td>
    <td class="tg-c3ow"></td>
  </tr>
  <tr  align="center">
    <td class="tg-abip">COUNT_DOWN</td>
    <td class="tg-abip" colspan="2">进入倒计时</td>
    <td class="tg-abip"></td>
    <td class="tg-abip"></td>
    <td class="tg-abip"></td>
  </tr>
  <tr  align="center">
    <td class="tg-c3ow">DECK</td>
    <td class="tg-c3ow" colspan="2">对方的卡组</td>
    <td class="tg-c3ow"></td>
    <td class="tg-c3ow">玩家的卡组</td>
    <td class="tg-c3ow"></td>
  </tr>
  <tr  align="center">
    <td class="tg-abip">FINGER_GUESS</td>
    <td class="tg-abip" colspan="2">猜拳结果</td>
    <td class="tg-abip"></td>
    <td class="tg-abip">玩家出拳</td>
    <td class="tg-abip"></td>
  </tr>
  <tr  align="center">
    <td class="tg-c3ow">CHAT</td>
    <td class="tg-c3ow" colspan="2">我方/对方的聊天消息</td>
    <td class="tg-c3ow"></td>
    <td class="tg-c3ow">玩家的聊天信息</td>
    <td class="tg-c3ow"></td>
  </tr>
  <tr  align="center">
    <td class="tg-abip">OPERATE</td>
    <td class="tg-abip" colspan="2">对方的操作</td>
    <td class="tg-abip"></td>
    <td class="tg-abip">玩家的操作</td>
    <td class="tg-abip"></td>
  </tr>
</table>