using App.Component3D;
using App.Utils;

namespace App
{
    public class AppManager
    {
        private WebRequestHelper _webRequestHelper;
        private Object3DManager _object3DManager;

        //웹데이터 로드 
        //오리지널 엔티티 보관
        //현재 앱 상태 보관 : 법인, 프로젝트
        //변경시  트리거

        public void Load()
        {
            // todo : req
            
            _object3DManager.OnProjectChanged();
            
            // todo : assetHierarchy.OnAssetChanged()
        }
    }
}