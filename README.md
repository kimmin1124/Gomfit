# 2021_SMU_DeepLearning_Injeolmi
SANGMYUNG UNIVERCITY_DL lecture_Team_Injeolmi_Developing a game using semantic segmentation

##### FSA-Net 깃헙 AI 모듈을 활용한 SW 프로그램입니다.
##### 이 소프트웨어는 FSA 기술의 활용을 보여줄 수 있는 게임 소프트웨어입니다.
##### 게임명인 곰피트는 곰돌이 (Gom) + 피트니스(Fitness) 의 합성어로 귀여운 곰과 함께 목 스트레칭을 통해 건강에 도움을 줄 수 있다는 뜻으로 이름지었습니다.

# https://github.com/shamangary/FSA-Net
###### 상단 링크에서 AI 모듈을 활용했으며 필요한 입력값으로의 변환함수를 작성하여 활용했습니다.


# 실행 모듈에 추가한 함수

def convert_para(tdx,x3):
    
    input_toUnity = 0;
    creteria = 15 #고개 회전 판단 기준값
    temp = tdx - x3
    
    if(temp > creteria):
        input_toUnity = 1
        print("Right, input_toUnity:{}".format(input_toUnity))
    elif((temp<=creteria) and (temp>=-creteria)):
        intput_toUnity = 0
        print("Center, input_toUnity:{}".format(input_toUnity))
    else:
        input_toUnity = -1
        print("Left, input_toUnity:{}".format(input_toUnity))
        
    return input_toUnity
